import React from "react";
import Button from "../button";
import { faTimes } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";


export default function Modal({ children, header, onClose }) {
    return <div className="modal-container">
        <div className="modal-header">
            <div>
                <h3>{header}</h3>
            </div>
            <Button onClick={onClose} wide={true}>{<FontAwesomeIcon icon={faTimes} size="lg" />}</Button>
        </div>
        {children}
    </div>
}