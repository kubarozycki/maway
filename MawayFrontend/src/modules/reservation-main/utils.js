import { RESERVATION_STEPS } from "./actions";
const isPreviousStepAvailable = currentStepIndex =>
  reservationStepIndex(currentStepIndex) === 0;
const isNextStepAvailable = currentStepIndex =>
  reservationStepIndex(currentStepIndex) === RESERVATION_STEPS.length - 1;
const reservationStepIndex = stepIndex =>
  RESERVATION_STEPS.findIndex(x => x.value === stepIndex);

const nextStepRoute = currentStepIndex =>
  RESERVATION_STEPS[currentStepIndex + 1];

const previousStepRoute = currentStepIndex =>
  RESERVATION_STEPS[currentStepIndex - 1];

export {
  isPreviousStepAvailable,
  isNextStepAvailable,
  reservationStepIndex,
  nextStepRoute,
  previousStepRoute
};
