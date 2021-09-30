import { BrowserRouter as Router, Route } from "react-router-dom";
import React from "react";
import DateStepComponent from "../../reservation-steps/date-step/components";
import ItemSelectStepComponent from '../../reservation-steps/item-selection-step/components'; 
import ExtrasStepComponent from '../../reservation-steps/extras-step/components';
import ConfirmationStepComponent from '../../reservation-steps/confirmation-step/components';
import PropTypes from "prop-types";
import { connect } from "react-redux";


function StepsContainer({currentStep, stepTitle}) {
  return (
    <div className="reservation-step-container">
      <h3>{stepTitle}</h3>
      {getCurrentStep(currentStep.value)}
    </div>
  );
}

const getCurrentStep = currentStepIndex => {
  switch (currentStepIndex) {
    case 0:
      return <DateStepComponent />;
    case 1:
      return <ItemSelectStepComponent />;
    case 2:
      return <ExtrasStepComponent/>;
    case 3:
      return <ConfirmationStepComponent/>
  }
};

const mapStateToProps = ({ reservationApp }) => {
    return {
        currentStep: reservationApp.currentStep,
        stepTitle: reservationApp.reservationSteps[reservationApp.currentStep.value].header 
      }
};

StepsContainer.propTypes = {
  reservationStep: PropTypes.shape({ value: PropTypes.number })
};

export default connect(mapStateToProps)(StepsContainer);
