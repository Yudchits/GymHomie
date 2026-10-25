import { ExerciseDropdownSearch } from "./exercise-search.js";
import { ExercisetSetCreate } from "./exercise-set-create.js";

const exercisesArray = [
    { id: 1, name: 'Push Up', muscles: ['Грудь', 'Трицепс'] },
    { id: 2, name: 'Incline Bench Press', muscles: ['Грудь', 'Трицепс'] },
    { id: 3, name: 'Squads', muscles: ['Ноги'] },
    { id: 4, name: 'Pull Up', muscles: ['Спина', 'Бицепс'] }
];
const exerciseSearchElement = new ExerciseDropdownSearch(exercisesArray);

const exercisesElement = document.querySelector('.exercises');
const exerciseSet = new ExercisetSetCreate(exerciseSearchElement);
exerciseSet.init(exercisesElement, 1);
