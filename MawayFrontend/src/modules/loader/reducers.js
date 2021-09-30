import { SHOW_LOADER, HIDE_LOADER } from "./actions";

const initialState = {
  isFetching: false
};

export default function loaderReducer(state = initialState, action) {
  switch (action.type) {
    case SHOW_LOADER:
      return {
        ...state,
        ...{
          isFetching: true
        }
      };
    case HIDE_LOADER:
      return {
        ...state,
        ...{
          isFetching: false
        }
      };
    default:
      return state;
  }
}
