import {
  ADD_EXTRAS,
  REMOVE_EXTRAS,
  REQUEST_EXTRAS,
  RECEIVE_EXTRAS,
  SELECTION_CHANGED
} from "./actions";

const initialState = {
  extras: []
};

export default function extrasStepReducer(state = initialState, action) {
  switch (action.type) {
    case ADD_EXTRAS:
      return {
        ...state,
        ...{}
      };
    case REMOVE_EXTRAS:
      return {
        ...state,
        ...{}
      };

    case REQUEST_EXTRAS:
      return {
        ...state,
        ...{
          isFetching: true
        }
      };
    case RECEIVE_EXTRAS:
      return {
        ...state,
        ...{
          isFetching: false,
          extras: action.extras
        }
      };
    case SELECTION_CHANGED:
      const extras = [...state.extras];
      const selectedExtrasIndex = extras.findIndex(x => x.id === action.id);
      extras[selectedExtrasIndex].selected = !extras[selectedExtrasIndex]
        .selected;

      return {
        ...state,
        ...{
          extras: extras
        }
      };
    default:
      return state;
  }
}
