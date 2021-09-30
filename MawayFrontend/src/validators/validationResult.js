export default class ValidationResult {
    constructor(validationPassed, validationMessage) {
        this.validationPassed = validationPassed;
        this.validationMessage = validationMessage;
    }
}