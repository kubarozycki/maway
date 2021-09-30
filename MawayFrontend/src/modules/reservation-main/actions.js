export const RESERVATION_STEPS = [
  { value: 0, name: "Select date", route: "date", valid: false, header: "Select reservation dates" },
  { value: 1, name: "Select item", route: "vehicele", valid: false, header: "Select vehicele" },
  { value: 2, name: "Select addons", route: "addons", valid: true, header: "Select extras" },
  { value: 3, name: "Finalize", route: "finalize", valid: false, header: "Provide us with some details" }
];

export const NEXT_STEP = "NEXT_STEP";
export const CHANGE_STEP = "CHANGE_STEP";

export const SET_STEP_VALID = "SET_STEP_VALID";
export const SET_STEP_INVALID = "SET_STEP_INVALID";

export const nextStep = () => ({ type: NEXT_STEP });
export const changeStep = (index) => ({ type: CHANGE_STEP, index: index });

export const setCurrentStepValid = () => ({ type: SET_STEP_VALID });
export const setCurrentStepInvalid = () => ({ type: SET_STEP_INVALID });
