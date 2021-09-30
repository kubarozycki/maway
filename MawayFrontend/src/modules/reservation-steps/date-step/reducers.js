import { DATE_CHANGED, CALENDAR_FOCUS_CHANGED } from './actions'

const initialState =
{
    dateFrom: null,
    dateTo: null,
    focusedInput: 'startDate'
}

export default function dateStepReducer(state = initialState, action)
{
    switch (action.type) {
        case DATE_CHANGED:
            return {
                ...state, ...{
                    dateFrom: action.dateFrom,
                    dateTo: action.dateTo
                }
            }
        case CALENDAR_FOCUS_CHANGED:
            return {
                ...state, ...{
                    focusedInput: action.focusedInput
                }
            }
        default:
            return state
    }
}