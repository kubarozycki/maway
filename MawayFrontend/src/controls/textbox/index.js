import React from "react";

export default ({ value, validationResult, placeholder, onChange }) => {
    return (
        <div className='textbox'>
            <input type='text' value={value} placeholder={placeholder} onChange={(event) => onChange(event.target.value)} />
            {!validationResult.isValid && <span>{validationResult.errorMsg}</span>}
        </div>
    )
}
