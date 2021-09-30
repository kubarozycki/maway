import React from "react";

export default function Checkbox({ text, price, isChecked=false, onChange }) {
  return (
    <div className="check-box">
      <div className="check-box-header">
        <label className="checkbox-container">
          <input
            type="checkbox"
            checked={isChecked}
            onChange={() => onChange()}
          ></input>
          <label>{text}</label>
          <span className="checkmark"></span>
        </label>
        <span className="price">{price} PLN</span>
      </div>
    </div>
  );
}
