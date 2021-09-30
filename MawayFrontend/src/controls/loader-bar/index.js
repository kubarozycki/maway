import React from "react";

export default function LoaderBar({ show }) {
    return <React.Fragment>
        {show && <div className="bar"></div>}
    </React.Fragment>
}