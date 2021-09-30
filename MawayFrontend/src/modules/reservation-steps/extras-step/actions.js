export const ADD_EXTRAS = "ADD_EXTRAS";
export const REMOVE_EXTRAS = "REMOVE_EXTRAS";
export const REQUEST_EXTRAS = "REQUEST_EXTRAS";
export const RECEIVE_EXTRAS = "RECEIVE_EXTRAS";
export const SELECTION_CHANGED = "SELECTION_CHANGED";

export function addExtras(id) {
  return { type: ADD_EXTRAS, id };
}

export function removeExtras(id) {
  return { type: REMOVE_EXTRAS, id };
}

export function requestExtras(itemTypeId) {
  return {
    type: REQUEST_EXTRAS,
    itemTypeId
  };
}

export function selectionChanged(id) {
  return {
    type: SELECTION_CHANGED,
    id
  };
}

const receiveExtras = data => ({
  type: RECEIVE_EXTRAS,
  extras: data
});

export function fetchExtras(itemTypeId) {
  return function(dispatch) {
    dispatch(requestExtras(itemTypeId));
    return fetch(
      `http://localhost:5000/api/Extras/itemExtras?itemTypeId=${itemTypeId}`
    )
      .then(
        response => response.json(),
        error => console.log("An error occurred.", error)
      )
      .then(json => dispatch(receiveExtras(json)));
  };
}
