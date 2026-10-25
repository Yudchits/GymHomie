import { Icon } from "../icon.js";

export class ExerciseDropdownSearch {
    #drowDownDisplayStyle = 'inline-block';
    #displayNoneStyle = 'none';
    #itemDisplayStyle = 'flex';
    #selectedExercise = null;
    #isOpened = false;

    constructor(exercisesArray) {
        this.exercisesArray = exercisesArray ?? [];
        this.dropdownElement = document.createElement('div');
        this.listElement = document.createElement('ul');
        this.#init();
    }

    #init() {
        this.dropdownElement.setAttribute('class', 'exercise-dropdown');
        this.dropdownElement.style.display = this.#displayNoneStyle;
        this.dropdownElement.style.position = 'absolute';

        const bodyElement = document.createElement('div');
        bodyElement.setAttribute('class', 'exercise-dropdown_body');

        this.listElement.setAttribute('class', 'exercise-dropdown__list');
        this.#renderList(this.exercisesArray);

        bodyElement.appendChild(this.listElement);
        this.dropdownElement.appendChild(bodyElement);
        document.body.appendChild(this.dropdownElement);
    }

    #renderList(exercisesArray) {
        exercisesArray.forEach(item => {
            const itemElement = document.createElement('li');
            itemElement.setAttribute('class', 'exercise-dropdown__item');
            itemElement.dataset.id = item.id;
            itemElement.addEventListener('mousedown', (_) => {
                this.#selectedExercise = item;
            });

            const iconElement = document.createElement('span')
            iconElement.setAttribute('class', 'exercise-dropdown__icon');
            const icon = new Icon(iconElement);
            icon.insertSvg("assets/bench-press.svg");

            const textElement = document.createElement('div');
            textElement.setAttribute('class', 'exercise-dropdown__text');

            const nameElement = document.createElement('span');
            nameElement.setAttribute('class', 'exercise-dropdown__name');
            nameElement.innerHTML = item.name;

            const musclesElement = document.createElement('ul');
            musclesElement.setAttribute('class', 'exercise-dropdown__muscles');

            item.muscles.forEach(muscle => {
                const muscleElement = document.createElement('li');
                muscleElement.setAttribute('class', 'exercise-dropdown__muscle');
                muscleElement.innerHTML = muscle;
                musclesElement.appendChild(muscleElement);
            });

            itemElement.appendChild(iconElement);
            textElement.appendChild(nameElement);
            textElement.appendChild(musclesElement);
            itemElement.appendChild(textElement);
            this.listElement.appendChild(itemElement);
        });
    }

    //TODO: remove listeners when exercise set is deleted
    handle(inputElement, onSelect = null) {
        inputElement.addEventListener('click', (event) => {
            this.#handleClick(event);
        });

        inputElement.addEventListener('input', (event) => {
            this.#handleInput(event);
        });

        inputElement.addEventListener('focusout', (event) => {
            this.#handleFocusOut(event, onSelect);
        });

        window.addEventListener('resize', (_) => {
            if (this.#isOpened) {
                const rect = inputElement.getBoundingClientRect();
                this.#setDropdownElementPosition(rect.top, rect.left, rect.width, rect.height);
            }
        });
    }

    #handleClick(event) {
        this.#isOpened = true;

        event.target.value = '';
        const filteredExercisesSet = this.#getFilteredExercisesSet('');
        this.#filterListElement(filteredExercisesSet);

        const rect = event.currentTarget.getBoundingClientRect();
        this.dropdownElement.style.display = this.listElement.hasChildNodes()
            ? this.#drowDownDisplayStyle
            : this.#displayNoneStyle;
        this.#setDropdownElementPosition(rect.top, rect.left, rect.width, rect.height);
    }

    #filterListElement(filteredExercisesSet) {
        Array.from(this.listElement.children).forEach(itemElement => {
            const id = Number(itemElement.dataset.id);
            itemElement.style.display = filteredExercisesSet.has(id)
                ? this.#itemDisplayStyle
                : this.#displayNoneStyle;
        });
    }

    #setDropdownElementPosition(top, left, width, height) {
        this.dropdownElement.style.width = `${width}px`;
        this.dropdownElement.style.left = `${left}px`;
        this.dropdownElement.style.top = `${top + height + window.scrollY}px`;
    }

    #handleInput(event) {
        const filteredExercisesSet = this.#getFilteredExercisesSet(event.target.value);
        this.#filterListElement(filteredExercisesSet);
    }

    #getFilteredExercisesSet(query) {
        query = query.trim().toLowerCase();

        if (!query)
            return new Set(this.exercisesArray.map(item => item.id));

        const filteredExercisesSet = new Set();

        this.exercisesArray.forEach(item => {
            const hasName = item.name.toLowerCase().includes(query);
            if (hasName) {
                filteredExercisesSet.add(item.id);
            }
        });

        return filteredExercisesSet;
    }

    #handleFocusOut(event, onSelect) {
        this.#isOpened = false;
        this.dropdownElement.style.display = this.#displayNoneStyle;
        onSelect?.(this.#selectedExercise);
        this.#selectedExercise = null;
    }
}