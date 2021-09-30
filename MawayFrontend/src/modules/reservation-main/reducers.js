import { RESERVATION_STEPS, NEXT_STEP, PREVIOUS_STEP, SET_STEP_VALID, SET_STEP_INVALID, CHANGE_STEP } from './actions';

const initialState =
{
    currentStep: RESERVATION_STEPS[0],
    reservationSteps: RESERVATION_STEPS,
    focusedInput: null,
    currentStepValid: () => this.reservationSteps.find(x => x.value === this.currentStep.index).valid,
    goingForward: true // this indicates if we need to reload reservation step date or not
}

function canGoToStep(targetStep, state) {
    for (var i = 0; i < targetStep.value; i++) {
        if (!state.reservationSteps[i].valid)
            return false;
    }
    return true;
}

export default function reservationApp(state = initialState, action) {
    switch (action.type) {
        case CHANGE_STEP:
            {
                const targetStep = RESERVATION_STEPS.find(x => x.value === action.index);
                return {
                    ...state, ...{
                        currentStep: canGoToStep(targetStep, state) ? targetStep : state.currentStep,
                        goingForward: targetStep > state.currentStep
                    }
                }
            }
        case NEXT_STEP:
            {
                const targetStep = RESERVATION_STEPS.find(x => x.value === state.currentStep.value + 1);
                return {
                    ...state, ...{
                        currentStep: canGoToStep(targetStep, state) ? targetStep : state.currentStep,
                        goingForward: true
                    }
                }
            }
        case SET_STEP_VALID: {
            const currenReservationSteps = state.reservationSteps;
            currenReservationSteps[state.currentStep.value].valid = true;
            return {
                ...state, ...{
                    reservationSteps: currenReservationSteps
                }
            }
        }
        case SET_STEP_INVALID: {
            const currenReservationSteps = state.reservationSteps;
            currenReservationSteps[state.currentStep.value].valid = false;
            return {
                ...state, ...{
                    reservationSteps: currenReservationSteps
                }
            }
        }
        default:
            return state
    }
}