import React from "react";
import { connect } from "react-redux";
import { fetchItems, changeSelection } from "../actions";
import Card from "../../../../controls/card";
import { showLoader, hideLoader } from "../../../loader/actions";
import {
  setCurrentStepInvalid,
  setCurrentStepValid,
  changeStep
} from "../../../reservation-main/actions";

class ItemSelectStepComponent extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.goingForward && this.props.onReloadItems(this.props.dateFrom, this.props.dateTo);
  }

  render() {
    if (!this.props.selectedItemId) this.props.onStepInvalid();
    else this.props.onStepValid();
    return (
      <div className="item-select-container">
        {this.props.items &&
          this.props.items.map(x => {
            return (
              <Card
                key={x.id}
                title={x.title}
                image={x.image}
                selected={this.props.selectedItemId === x.id}
                attributes={x.itemAttributes}
                onClick={() => this.props.onChangeSelection(x.id)}
                dailyPrice={x.dailyPrice}
              />
            );
          })}
      </div>
    );
  }
}

const mapStateToProps = ({ dateStepReducer, itemStepReducer, reservationApp }) => ({
  items: itemStepReducer.items,
  dateFrom: dateStepReducer.dateFrom,
  dateTo: dateStepReducer.dateTo,
  selectedItemId: itemStepReducer.selectedItemId,
  goingForward: reservationApp.goingForward
});

const mapDispatchToProps = dispatch => ({
  onReloadItems: (dateFrom, dateTo) => {
    dispatch(showLoader());
    dispatch(fetchItems(dateFrom, dateTo)).then(() => dispatch(hideLoader()));
  },
  onChangeSelection: selectedItemId => dispatch(changeSelection(selectedItemId)),
  onStepInvalid: () => dispatch(setCurrentStepInvalid()),
  onStepValid: () => dispatch(setCurrentStepValid())
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ItemSelectStepComponent);
