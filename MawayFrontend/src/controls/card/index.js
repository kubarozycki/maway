import React from "react";
import PropTypes from "prop-types";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import moneyPipe from '../../pipes/moneyPipe';

export default function Card({ title, image, attributes, selected, onClick, dailyPrice }) {
  return (
    <div className={'item-card'+ (selected ? ' selected-item-card':'')} onClick={onClick}>
      <div className="card-header">
        <span className="title">{title}</span>
        <span className="price">{moneyPipe(dailyPrice)}/day</span>
      </div>
      <div className="card-body">
        <img src={image} className="card-img"></img>
        <div className="item-description">
          <div className="item-attributes description-section">
            {attributes.map(a => {
              return (
                <div className="attributes-container" key={a.key}>
                  <div className="icon">
                    <FontAwesomeIcon icon={a.icon} size="lg" />
                  </div>
                  <div className="value">{a.value}</div>
                </div>
              );
            })}
          </div>
          <div className="price-container description-section">
            
          </div>
        </div>
      </div>
    </div>
  );
}

Card.propTypes = {
  title: PropTypes.string,
  image: PropTypes.string,
  attributes: PropTypes.arrayOf(
    PropTypes.shape({
      key: PropTypes.string.isRequired,
      value: PropTypes.string.isRequired,
      icon: PropTypes.string
    })
  )
};

Card.defaultProps = {
  disabled: false
};
