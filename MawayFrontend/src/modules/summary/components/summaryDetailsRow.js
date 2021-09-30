import React from "react";

export default function SummaryDetailsRow({ name, value }) {
    return (<div className='summary-details-row'>
        <div className='name'>{name}</div>
        <div className='value'>{value}</div>
    </div>)
}
