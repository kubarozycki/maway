import React from "react";
import { connect } from "react-redux";
import { fetchExtras, selectionChanged } from "../actions";
import {
  nextStep,
  setCurrentStepValid,
  setCurrentStepInvalid,
  changeStep
} from "../../../reservation-main/actions";
import { showLoader, hideLoader } from "../../../loader/actions";
import Checkbox from "../../../../controls/checkbox";

class ExtrasStepComponent extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.goingForward && this.props.onReloadExtras(this.props.selectedItemId);
  }

  render() {
    return (
      <div className="extras-container">
        {this.props.extras &&
          this.props.extras.map(x => {
            return (
              <div className="extras-item" key={x.id} onClick={() => this.props.onSelectionChange(x.id)}>
                <Checkbox
                  isChecked={x.selected}
                  text={x.name}
                  price={x.price}
                  onChange={() => this.props.onSelectionChange(x.id)}
                />
              </div>
            );
          })}
      </div>
    );
  }
}

const mapStateToProps = ({ extrasStepReducer, itemStepReducer, reservationApp }) => {
  return {
    extras: extrasStepReducer.extras,
    selectedExtras: extrasStepReducer.selectedExtras,
    selectedItemId: itemStepReducer.selectedItemId,
    goingForward: reservationApp.goingForward
  };
};

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    onReloadExtras: itemTypeId => {
      dispatch(showLoader());
      dispatch(fetchExtras(itemTypeId)).then(() => dispatch(hideLoader()));
    },
    onStepConfirmed: () => dispatch(changeStep(2)),
    onInvalidStep: () => dispatch(setCurrentStepInvalid()),
    onValidStep: () => dispatch(setCurrentStepValid()),
    onSelectionChange: id => dispatch(selectionChanged(id))
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ExtrasStepComponent);
