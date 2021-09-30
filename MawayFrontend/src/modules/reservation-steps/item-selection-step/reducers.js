import { REQUEST_ITEMS, RECEIVE_ITEMS, CHANGE_SELECTION } from "./actions";

const initialState = {
  isFetching: false,
  items: [],
  selectedItemId: null
};

export default function itemStepReducer(state = initialState, action) {
  switch (action.type) {
    case REQUEST_ITEMS:
      return {
        ...state,
        ...{
          isFetching: true,
          selectedItemId: null
        }
      };
    case RECEIVE_ITEMS:
      return {
        ...state,
        ...{
          isFetching: false,
          items: action.items
        }
      };
    case CHANGE_SELECTION:
      return {
        ...state,
        ...{
          selectedItemId: action.selectedItemId
        }
      };
    default:
      return state;
  }
}
