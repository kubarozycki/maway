export const FORM_CONFIRMED = 'FORM_CONFIRMED'
export const VALUE_CHANGED = 'VALUE_CHANGED';

export const NAME_FIELD = 'NAME_FIELD';
export const SURNAME_FIELD = 'SURNAME_FIELD';
export const EMAIL_FIELD = 'EMAIL_FIELD';
export const PHONE_FIELD = 'PHONE_FIELD';

export function formConfirmed() {
    return { type: FORM_CONFIRMED }
}

export function valueChanged(field, value) {
    return { type: VALUE_CHANGED, field, value }
}

