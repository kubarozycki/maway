import React from 'react';
import { connect } from 'react-redux';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendar, faCarSide, faPlus, faClipboardCheck } from '@fortawesome/free-solid-svg-icons';
import { RESERVATION_STEPS, previousStep, changeStep } from '../actions';
import { withRouter } from 'react-router-dom';

const steps = [
    {
        key: RESERVATION_STEPS[0].value,
        icon: faCalendar,
        title: 'Date',
    },
    {
        key: RESERVATION_STEPS[1].value,
        icon: faCarSide,
        title: 'Vehicele',
    },
    {
        key: RESERVATION_STEPS[2].value,
        icon: faPlus,
        title: 'Extras',
    },
    {
        key: RESERVATION_STEPS[3].value,
        icon: faClipboardCheck,
        title: 'Confirm',
    }];

function ReservationStepsState(props) {
    return <div className="steps-container">
        {steps.map(x => {
            return <div className="step" key={x.key} onClick={()=>{
                props.currentStep.value > x.key && props.onPreviousStepClick(x.key);}}>
                <div className={getStepIcon(x.key, props.currentStep.value)}>
                    <div className="icon-placeholder">
                        <FontAwesomeIcon icon={x.icon} size="lg" />
                    </div>
                </div>
                <div className="step-footer">
                    {x.title}
                </div>
            </div>
        })}

    </div>
}

const getStepIcon = (stepValue, currentStepValue) => {
    return stepValue === currentStepValue ? 'active step-circle' : 'step-circle';
}

const mapDispatchToProps = dispatch => ({
    onPreviousStepClick: (index) => dispatch(changeStep(index))
});


const mapStateToProps = ({ reservationApp }) => {
    return {
        currentStep: reservationApp.currentStep
    }
}

export default connect(
    mapStateToProps, mapDispatchToProps
)(ReservationStepsState)