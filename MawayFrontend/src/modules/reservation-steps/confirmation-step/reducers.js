import {EMAIL_FIELD, NAME_FIELD, PHONE_FIELD, SURNAME_FIELD, VALUE_CHANGED, FORM_CONFIRMED} from './actions';

const requiredValidator = (value) => !!value;
const maxLengthValidator = (value, maxLength) => !!value && value.length < maxLength;
const minLengthValidator = (value, minLength) => !!value && value.length >= minLength;

const formValidators = {
    [NAME_FIELD]: [ {validatorFn: requiredValidator, errorMsg: 'Name is required'}, {validatorFn:  value => minLengthValidator(value,2), errorMsg: 'Name should be minimum 2 characters long'}],
    [SURNAME_FIELD]: [ {validatorFn: requiredValidator, errorMsg: 'Surname is required'}, {validatorFn:  value => minLengthValidator(value,2), errorMsg: 'Surname should be minimum 2 characters long'}],
    [EMAIL_FIELD]: [ {validatorFn: requiredValidator, errorMsg: 'Email is required'}],
    [PHONE_FIELD]: [ {validatorFn: requiredValidator, errorMsg: 'Phone number is required'}]
}


const initialState =
    {
        formValues: {
            [NAME_FIELD]: '',
            [SURNAME_FIELD]: '',
            [EMAIL_FIELD]: '',
            [PHONE_FIELD]: ''
        },
        formValidation: {
            [NAME_FIELD]: { isValid: false, errorMsg: '' },
            [SURNAME_FIELD]: { isValid: false, errorMsg: '' },
            [EMAIL_FIELD]: { isValid: false, errorMsg: '' },
            [PHONE_FIELD]: { isValid: false, errorMsg: '' }
        }
    }





export default function confirmationStepReducer(state = initialState, action) {
    switch (action.type) {
        case FORM_CONFIRMED:
            const formValidatonResults = {
                [NAME_FIELD]: { isValid: true, errorMsg: '' },
                [SURNAME_FIELD]: { isValid: true, errorMsg: '' },
                [EMAIL_FIELD]: { isValid: true, errorMsg: '' },
                [PHONE_FIELD]: { isValid: true, errorMsg: '' }
            };
            for (let formFieldKey in state.formValidation) {
                const fieldValidators = formValidators[formFieldKey];
                const fieldProposedValue = state.formValues[formFieldKey];

                for(let validator of fieldValidators)
                {
                    const isValid = validator.validatorFn(fieldProposedValue);
                    if(!isValid) {
                        formValidatonResults[formFieldKey] = { isValid,errorMsg: validator.errorMsg };
                        break;
                    }
                }
            }

            return {
                ...state,
                formValidation: formValidatonResults
            }
        case VALUE_CHANGED:
            return {
                ...state,
                formValues: { ...state.formValues, [action.field]: action.value }
            }
        default:
            return state
    }
}
