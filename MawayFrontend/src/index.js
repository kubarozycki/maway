import React from "react";
import { createStore, combineReducers, applyMiddleware } from "redux";
import reservationApp from "./modules/reservation-main/reducers";
import { render } from "react-dom";
import dateStepReducer from "./modules/reservation-steps/date-step/reducers";
import itemStepReducer from "./modules/reservation-steps/item-selection-step/reducers";
import loaderReducer from "./modules/loader/reducers";
import extrasStepReducer from './modules/reservation-steps/extras-step/reducers';
import summaryReducer from './modules/summary/reducers';
import confirmationStepReducer from './modules/reservation-steps/confirmation-step/reducers';
import thunkMiddleware from "redux-thunk";
import Root from "./views/root";

console.log(process.env);

const store = createStore(
  combineReducers({
    reservationApp,
    dateStepReducer,
    itemStepReducer,
    extrasStepReducer,
    loaderReducer, 
    summaryReducer,
    confirmationStepReducer
  }),
  applyMiddleware(thunkMiddleware)
);

render(<Root store={store} />, document.getElementById("root"));
