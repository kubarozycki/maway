import ValidationResult from './validationResult';

const IS_REQUIRED_INVALID_MESSAGE = 'This field is required';

const isRequired = (value) => value ? new ValidationResult(true) : new ValidationResult(false, IS_REQUIRED_INVALID_MESSAGE);

const validateValue = (value, validators) => {
    validators.forEach(validator => {
        const result = validator(value);
        if (!result.validationPassed)
            return result;
    });

    return new ValidationResult(true);
}

export default { isRequired, validateValue };