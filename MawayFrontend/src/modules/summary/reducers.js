import {
    REQUEST_SUMMARY,
    RECEIVE_SUMMARY,
    CLOSE_SUMMARY_MODAL,
    OPEN_SUMMARY_MODAL
} from "./actions";

const initialState = {
    isPopupOpen: false,
    isFetching: false
};

export default function summaryReducer(state = initialState, action) {
    switch (action.type) {
        case REQUEST_SUMMARY:
            return {
                ...state,
                ...{
                    isFetching: true
                }
            };
        case RECEIVE_SUMMARY:
            return {
                ...state,
                ...{
                    isFetching: false,
                    data: action.data
                }
            };
        case CLOSE_SUMMARY_MODAL:
            return {
                ...state,
                ...{
                    isPopupOpen: false
                }
            };
        case OPEN_SUMMARY_MODAL:
            return {
                ...state,
                ...{
                    isPopupOpen: true
                }
            };
        default:
            return state;
    }
}
