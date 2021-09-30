import React from "react";
import { DateRangePicker } from "react-dates";
import { connect } from "react-redux";
import "react-dates/initialize";
import "react-dates/lib/css/_datepicker.css";
import { dateChanged, dateFocusChanged, RESERVATION_STEPS } from "../actions";
import { nextStep, setCurrentStepValid, setCurrentStepInvalid, changeStep } from "../../../reservation-main/actions";

class DateStepComponent extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    if (!validateDateStep(this.props.startDate, this.props.endDate))
      this.props.onInvalidStep();
    else this.props.onValidStep();
    return (
      <div className="range-picker-container">
        <DateRangePicker
          startDate={this.props.startDate}
          startDateId="your_unique_start_date_id"
          endDate={this.props.endDate}
          endDateId="your_unique_end_date_id"
          onDatesChange={({ startDate, endDate }) =>
            this.props.onDateChanged(startDate, endDate)
          }
          focusedInput={this.props.focusedInput}
          onFocusChange={focus => {
            this.props.onFocusChange(focus);
          }}
          numberOfMonths={1}
          keepOpenOnDateSelect={true}
        />
      </div>
    );
  }
}

const mapStateToProps = ({ dateStepReducer, reservationApp }) => {
  return {
    currentStep: reservationApp.currentStep,
    startDate: dateStepReducer.dateFrom,
    endDate: dateStepReducer.dateTo,
    focusedInput: dateStepReducer.focusedInput
  };
};

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    onDateChanged: (dateFrom, dateTo) => dispatch(dateChanged(dateFrom, dateTo)),
    onFocusChange: focusedInput => dispatch(dateFocusChanged(focusedInput)),
    onStepConfirmed: () => dispatch(changeStep(1)),
    onInvalidStep: () => dispatch(setCurrentStepInvalid()),
    onValidStep: () => dispatch(setCurrentStepValid())
  };
};

const validateDateStep = (from, to) => from && to;
export default connect(mapStateToProps, mapDispatchToProps)(DateStepComponent);
