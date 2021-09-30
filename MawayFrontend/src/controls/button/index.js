import React from 'react';
import PropTypes from 'prop-types';

export default function Button({ onClick, disabled, wide, children }) {
    return <button
        type='button'
        className={'mawayButton ' + (disabled && 'disabled ') + (wide && ' wide')}
        onClick={() => !disabled && onClick()}
    >{children}</button>
}

Button.propTypes = {
    disabled: PropTypes.bool,
    onClick: PropTypes.func,
    wide: PropTypes.bool
}

Button.defaultProps = {
    disabled: false
};
