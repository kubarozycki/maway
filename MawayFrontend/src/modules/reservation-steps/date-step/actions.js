
export const DATE_CHANGED = 'DATE_CHANGED'
export const CALENDAR_FOCUS_CHANGED = 'CALENDAR_FOCUS_CHANGED'
export function dateChanged(dateFrom, dateTo)
{
    return { type: DATE_CHANGED, dateFrom, dateTo }
}

export function dateFocusChanged(focusedInput)
{
    return { type: CALENDAR_FOCUS_CHANGED, focusedInput }
}