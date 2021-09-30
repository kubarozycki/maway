export const REQUEST_ITEMS = "REQUEST_ITEMS";
export const RECEIVE_ITEMS = "RECEIVE_ITEMS";
export const CHANGE_SELECTION = "CHANGE_SELECTION";

function requestItems(startDate, endDate) {
  return {
    type: REQUEST_ITEMS,
    startDate,
    endDate
  };
}

export function changeSelection(selectedItemId) {
  return {
    type: CHANGE_SELECTION,
    selectedItemId
  }
}

const receiveItems = data => ({
  type: RECEIVE_ITEMS,
  items: data
});

export function fetchItems(startDate, endDate) {
  return function(dispatch) {
    dispatch(requestItems(startDate, endDate));
    return fetch(
      `http://localhost:5000/api/Item/availableItems?From=${startDate.format("MM-DD-YYYY")}&To=${endDate.format("MM-DD-YYYY")}`
    )
      .then(
        response => response.json(),
        error => console.log("An error occurred.", error)
      )
      .then(json => dispatch(receiveItems(json)));
  };
}
