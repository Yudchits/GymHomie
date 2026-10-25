const defaultExerciseSetTitle = 'Упражнение без названия';
const defaultSetRowsValue = 1;
const minSetRows = 1;
const maxSetRows = 30;
const setProperties = [
    { Name: 'Reps', labelText: 'Повт.' },
    { Name: 'Weight', labelText: 'Вес, кг' },
    { Name: 'RestTimeSeconds', labelText: 'Отдых, с' }
];

export class ExercisetSetCreate {
    #titleElement;
    #exerciseIdInputElement;
    #exerciseNameInputElement;

    #exerciseSetsState = {
        inputElement: null,
    }

    #similarSetsState = {
        element: null,
        clickHandler: null
    }

    #exerciseSetPropertiesState = {
        element: null,
        clickHandler: null
    }

    #addExerciseSetState = {
        element: null,
        clickHandler: null
    }

    constructor(exerciseSearchElement) {
        this.exerciseSearchElement = exerciseSearchElement;
    }

    init(containerElement, order) {
        if (!containerElement || order < 1)
            return;

        const guid = crypto.randomUUID();

        const setsId = `sets-${guid}`;
        const similarSetsId = `similar-sets-${guid}`;
        const exerciseId = `exercise-${guid}`;
        const exerciseNameId = `exercise-name-${guid}`;
        const addSetBtnId = `add-set-btn-${guid}`;

        const exerciseSetElement = this.#createExerciseSetElement(order, setsId, similarSetsId, exerciseId, exerciseNameId, addSetBtnId);
        containerElement.appendChild(exerciseSetElement);
        this.#initElements(containerElement, setsId, similarSetsId, exerciseId, exerciseNameId, addSetBtnId);
        this.#renderSetRows(defaultSetRowsValue);
        this.#addListeners();
    }

    destroy() {

    }

    #createExerciseSetElement(order, setsId, similarSetsId, exerciseId, exerciseNameId, addSetBtnId) {
        const exerciseSetElement = document.createElement('li');

        exerciseSetElement.innerHTML = `
            <div class="bg-primary rounded-md">
                <div class="d-flex justify-content-between align-items-center border-bottom p-2">
                    <div class="d-flex align-items-center">
                        <span class="d-flex justify-content-center align-items-center bg-accent-soft text-accent rounded-sm" style="width: 1.7em; height: 1.7em;">${order}</span>
                        <h3 class="text-ink ml-1" data-target="card-title">${defaultExerciseSetTitle}</h3>
                    </div>
                    <div>
                        <button data-target="deleteExerciseSet" class="btn btn-borderless p-1" type="button">
                            <svg class="text-red">
                                <use href="#trash"></use>
                            </svg>
                        </button>
                    </div>
                </div>
                <div class="p-3">
                    <input type="hidden" name="ExerciseId" id="${exerciseId}">

                    <div class="bg-primary-light rounded-sm p-2 field">
                        <label for="${exerciseNameId}" class="text-uppercase">Название упражнения</label>
                        <input type="text" id="${exerciseNameId}" class="control bg-primary w-100" maxlength="64" placeholder="Введите название упражнения">
                    </div>
                    <div class="row field mt-1">
                        <label for="${setsId}" class="text-uppercase">Сеты</label>
                        <input id="${setsId}" class="control" type="number" name="SetsCount" style="width: 60px;">
                    </div>
                    <div class="row bg-primary-light p-2 mt-1 rounded-sm">
                        <div>
                            <p class="text-ink lh-sm">Одинаковые сеты</p>
                            <p class="fs-6">Параметры автоматически применятся ко всем сетам</p>
                        </div>
                        <label for="${similarSetsId}" class="switch">
                            <input type="checkbox" id="${similarSetsId}" class="d-none" name="HasSimilarSets">
                            <span></span>
                        </label>
                    </div>
                    <table class="w-100 mt-2">
                        <thead>
                            <tr class="fs-6">
                                ${this.#renderSetPropertiesTableHeader()}
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                    <button id="${addSetBtnId}" class="btn btn-hover btn-dashed border-accent text-accent mt-1">
                        <span class="icon plus-icon"></span>
                        Добавить сет
                    </button>
                </div>
            </div>
        `;

        return exerciseSetElement;
    }

    #renderSetPropertiesTableHeader() {
        const css = 'ls-sm text-left text-uppercase border-bottom';

        let result = `<th class="${css}">Сет</th>`;
        setProperties.forEach(property => {
            result += `<th class="${css}">${property.labelText}</th>`
        });
        result += `<th class="${css}">&nbsp;</th>`

        return result;
    }

    #initElements(containerElement, setsId, similarSetsId, exerciseId, exerciseNameId, addSetBtnId) {
        this.#titleElement = containerElement.querySelector("[data-target='card-title']");
        this.#exerciseIdInputElement = containerElement.querySelector(`#${exerciseId}`);
        this.#exerciseNameInputElement = containerElement.querySelector(`#${exerciseNameId}`);
        this.#exerciseSetsState.inputElement = containerElement.querySelector(`#${setsId}`);
        this.#similarSetsState.element = containerElement.querySelector(`#${similarSetsId}`);
        this.#exerciseSetPropertiesState.element = containerElement.querySelector('table tbody');
        this.#addExerciseSetState.element = containerElement.querySelector(`#${addSetBtnId}`);
    }

    #addListeners() {
        if (!this.exerciseSearchElement)
            return;

        this.exerciseSearchElement.handle(this.#exerciseNameInputElement, (exercise) => {
            this.#exerciseNameInputElement.value = exercise?.name ?? '';
            this.#exerciseIdInputElement.value = exercise?.id ?? 0;
            this.#titleElement.innerText = exercise?.name ?? defaultExerciseSetTitle;
        });

        this.#subcribeOnFocusSetsOutListener();
        this.#subscribeOnAddSetClick();
        this.#subscribeOnSetPropertiesClick();
        this.#subscriberOnSimilarSetsClick();
    }

    #subcribeOnFocusSetsOutListener() {
        this.#exerciseSetsState.inputElement.addEventListener('focusout', (event) => {
            let value = event.target.value;
            const valueNumber = Number(value);

            let newRowSetsValue = valueNumber;
            if (!value || valueNumber < minSetRows)
                newRowSetsValue = minSetRows;

            if (valueNumber > maxSetRows)
                newRowSetsValue = Number(value.slice(0, -1));

            this.#exerciseSetsState.inputElement.value = newRowSetsValue;

            if (!this.#similarSetsState.element.checked)
                this.#renderSetRows(newRowSetsValue);
            else
                this.#exerciseSetsState.inputElement.value = newRowSetsValue;
        });
    }

    #subscribeOnSetPropertiesClick() {
        if (this.#exerciseSetPropertiesState.clickHandler)
            return;

        this.#exerciseSetPropertiesState.clickHandler = (ev) => {
            const deleteExerciseSetBtn = ev.target.closest("[data-target='deleteExerciseSetRow']");
            if (deleteExerciseSetBtn) {
                this.#deleteExerciseSetRowElement(deleteExerciseSetBtn);
            }
        };

        this.#exerciseSetPropertiesState.element.addEventListener('click', this.#exerciseSetPropertiesState.clickHandler);
    }

    #renderSetRows(newRowsNumber) {
        if (newRowsNumber < 1)
            newRowsNumber = 1;

        const rows = this.#exerciseSetPropertiesState.element.querySelectorAll('tr');
        if (!rows)
            return;

        const rowsLength = rows.length;
        if (rowsLength === newRowsNumber)
            return;

        if (newRowsNumber < rowsLength) {
            for (let rowIndex = rowsLength - 1; rowIndex >= newRowsNumber; rowIndex -= 1) {
                rows[rowIndex].remove();
            }
        }
        else {
            for (let rowIndex = rowsLength; rowIndex < newRowsNumber; rowIndex += 1) {
                const rowElement = this.#createExerciseSetRowElement(rowIndex + 1);

                this.#exerciseSetPropertiesState.element.appendChild(rowElement);
            }
        }

        this.#similarSetsState.element.disabled = newRowsNumber === 1;
        this.#exerciseSetsState.inputElement.value = newRowsNumber;
    }

    #createExerciseSetRowElement(setNumber) {
        const rowElement = document.createElement('tr');

        const setTdElement = document.createElement('td');
        setTdElement.innerText = setNumber;

        rowElement.appendChild(setTdElement);

        setProperties.forEach(item => {
            const field = this.#createExerciseSetPropertyElement(item.Name);
            rowElement.appendChild(field);
        });

        const actionTdElement = document.createElement('td');
        actionTdElement.innerHTML = `<button data-target="deleteExerciseSetRow" class="btn btn-borderless p-1" type="button">
            <svg class="text-red">
                <use href="#trash"></use>
            </svg>
        </button>`;

        rowElement.appendChild(actionTdElement);

        return rowElement;
    }

    #createExerciseSetPropertyElement(name) {
        const tdElement = document.createElement('td');
        tdElement.innerHTML = `<input name="${name}" class="control w-100" type="number" placeholder="0">`;
        return tdElement;
    }

    #subscribeOnAddSetClick() {
        this.#addExerciseSetState.clickHandler = (_) => {
            const newRowsLength = Number(this.#exerciseSetsState.inputElement.value) + 1;

            if (!this.#similarSetsState.element.checked)
                this.#renderSetRows(newRowsLength);
            else
                this.#exerciseSetsState.inputElement.value = newRowsLength;
        };

        this.#addExerciseSetState.element.addEventListener('click', this.#addExerciseSetState.clickHandler);
    }

    #subscriberOnSimilarSetsClick() {
        this.#similarSetsState.clickHandler = (ev) => {
            const rows = this.#exerciseSetPropertiesState.element.querySelectorAll('tr');
            if (!rows)
                return;

            if (ev.target.checked) {
                if (rows.length <= 1)
                    return;

                for (let i = 1; i < rows.length; i += 1) {
                    rows[i].remove();
                }
            } else {
                this.#renderSetRows(this.#exerciseSetsState.inputElement.value);
            }
        };

        this.#similarSetsState.element.addEventListener('click', this.#similarSetsState.clickHandler);
    }

    #deleteExerciseSetRowElement(btn) {
        if (!btn)
            return;

        const trToDelete = btn.closest('tr');
        if (!trToDelete)
            return;

        const setNumber = Number(trToDelete.firstChild.innerText);
        if (!setNumber)
            return;

        const rows = this.#exerciseSetPropertiesState.element.querySelectorAll('tr');
        if (rows.length === 1)
            return;

        for (const row of rows) {
            const currentIndex = Number(row.firstChild.innerText);
            if (currentIndex > setNumber) {
                row.firstChild.innerText = currentIndex - 1;
            }
        }

        const newRowsLength = Number(this.#exerciseSetsState.inputElement.value) - 1;
        this.#exerciseSetsState.inputElement.value = newRowsLength;
        trToDelete.remove();

        if (newRowsLength === 1)
            this.#similarSetsState.element.disabled = true;
    }
}