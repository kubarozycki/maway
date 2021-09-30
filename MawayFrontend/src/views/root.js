import React from "react";
import PropTypes from "prop-types";
import { Provider } from "react-redux";
import ReservationStepsState from "../modules/reservation-main/components/reservationStepsState";
import ReservationStepsNav from "../modules/reservation-main/components/reservationStepsNav";
import StepsContainer from "../modules/reservation-main/components/stepsContainer";
import "../styles/App.scss";
import { BrowserRouter as Router, Route } from "react-router-dom";
import Loader from '../modules/loader/components';

function Root({ store }) {
  return (
    <div className="reservation-container">
      <Provider store={store}>
        <Router>
          <ReservationStepsState />
          <Loader/>
          <StepsContainer/>
          <ReservationStepsNav />
        </Router>
      </Provider>
    </div>
  );
}

Root.propTypes = {
  store: PropTypes.object.isRequired
};
export default Root;
