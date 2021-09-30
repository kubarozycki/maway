import React from "react";
import { connect } from "react-redux";
import TextBox from '../../../../controls/textbox';
import SummaryComponent from '../../../summary/components';
import { valueChanged, formConfirmed, NAME_FIELD, SURNAME_FIELD, EMAIL_FIELD, PHONE_FIELD } from "../actions";
import Button from "../../../../controls/button";

class ConfirmationStepComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { formValues, formValidation, onFieldChange, onConfirm } = this.props;
        return (
            <div className='confirmation-container'>
                <div className="confirmation-form">
                    <form>
                        <TextBox value={formValues[NAME_FIELD]} validationResult={formValidation[NAME_FIELD]} onChange={(value) => onFieldChange(NAME_FIELD, value)} placeholder='Name' />
                        <TextBox value={formValues[SURNAME_FIELD]} validationResult={formValidation[SURNAME_FIELD]} onChange={(value) => onFieldChange(SURNAME_FIELD, value)} placeholder='Surname' />
                        <TextBox value={formValues[EMAIL_FIELD]} validationResult={formValidation[EMAIL_FIELD]} onChange={(value) => onFieldChange(EMAIL_FIELD, value)} placeholder='Email' />
                        <TextBox value={formValues[PHONE_FIELD]} validationResult={formValidation[PHONE_FIELD]} onChange={(value) => onFieldChange(PHONE_FIELD, value)} placeholder='Phone number' />
                        <div className='confirmation-row'>
                            <div className='summary-trigger-container'>
                                <SummaryComponent />
                            </div>
                            <Button onClick={()=> onConfirm()}>Confirm</Button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}

const mapStateToProps = ({ confirmationStepReducer }) => {
    return {
        formValues: confirmationStepReducer.formValues,
        formValidation: confirmationStepReducer.formValidation
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        onFieldChange: (fieldName, value) => dispatch(valueChanged(fieldName, value)),
        onConfirm: () => dispatch(formConfirmed())
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(ConfirmationStepComponent);
