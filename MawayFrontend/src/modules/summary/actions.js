export const REQUEST_SUMMARY = "REQUEST_SUMMARY";
export const RECEIVE_SUMMARY = "RECEIVE_SUMMARY";
export const CLOSE_SUMMARY_MODAL = "CLOSE_SUMMARY_MODAL";
export const OPEN_SUMMARY_MODAL = "OPEN_SUMMARY_MODAL";


export function closeSummaryModal() {
  return {
    type: CLOSE_SUMMARY_MODAL,
    isPopupOpen: false
  }
}

export function openSummaryModal() {
  return {
    type: OPEN_SUMMARY_MODAL,
    isPopupOpen: true
  }
}

export function requestSummary(itemTypeId) {
  return {
    type: REQUEST_SUMMARY,
    itemTypeId
  };
}


const receiveSummary = data => ({
  type: RECEIVE_SUMMARY,
  data
});

export function fetchSummary(itemTypeId, extrasIds, from, to) {
  return function (dispatch) {
    dispatch(requestSummary(itemTypeId));
    return fetch(
      `http://localhost:5000/api/Summary/getReservationSummary`,
      {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ itemTypeId, extrasIds, from, to })
      }
    )
      .then(
        response => response.json(),
        error => console.log("An error occurred.", error)
      )
      .then(json => dispatch(receiveSummary(json)));
  };
}
