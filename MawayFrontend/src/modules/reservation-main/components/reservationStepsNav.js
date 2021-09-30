import React from "react";
import Button from "../../../controls/button";
import { connect } from "react-redux";
import { RESERVATION_STEPS, nextStep, previousStep } from "../actions";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import PropTypes from "prop-types";
import SummaryComponent from '../../summary/components';

function ReservationStepsNav({
  onNextStepClick,
  currentStepValid,
  isLastStep,
  isFirstStep
}) {
  if (currentStepValid)
    return (
      <div className="reservation-steps-navigation">
        <div className="buttons-container">
          <div className="left-container summary-trigger-container">
            {!isFirstStep && <SummaryComponent />}
          </div>
          <div className="right-container">
            <Button
              onClick={onNextStepClick}
            >
              {isLastStep ? "Confirm" : "Next"}
            </Button>
          </div>
        </div>
      </div>
    );
  else
    return (<React.Fragment></React.Fragment>)
}

const mapStateToProps = ({ reservationApp }) => ({
  currentStepValid: reservationApp.reservationSteps[reservationApp.currentStep.value].valid,
  isLastStep: reservationApp.reservationSteps.length === reservationApp.currentStep.value + 1,
  isFirstStep: reservationApp.currentStep.value === 0
});

const mapDispatchToProps = dispatch => ({
  onNextStepClick: () => dispatch(nextStep())
});

ReservationStepsNav.propTypes = {
  currentStep: PropTypes.shape({ value: PropTypes.number })
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ReservationStepsNav);
