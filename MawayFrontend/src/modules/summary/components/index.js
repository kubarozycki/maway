import React from "react";
import { connect } from "react-redux";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faShoppingCart } from "@fortawesome/free-solid-svg-icons";
import ModalPortal from "../../../portals/modal";
import Modal from "../../../controls/modal";
import SummaryDetailsComponent from './summaryDetails';
import { openSummaryModal, closeSummaryModal } from "../actions";

class SummaryComponent extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    this.props.goingForward && this.props.onReloadExtras(this.props.selectedItemId);
  }

  render() {
    return (
      <React.Fragment>
        <FontAwesomeIcon icon={faShoppingCart} size='lg' onClick={this.props.onSummaryPopupTriggerClick} />
        {this.props.isPopupOpen && <ModalPortal>
          <Modal header={'Reservation summary'} onClose={this.props.onSummaryPopupClose}>
            <SummaryDetailsComponent/>
          </Modal>
        </ModalPortal>}
      </React.Fragment>
    );
  }
}

const mapStateToProps = ({ reservationApp, extrasStepReducer, itemStepReducer, summaryReducer }) => {
  return {
    currentStep: extrasStepReducer.selectedExtras,
    selectedItemId: itemStepReducer.selectedItemId,
    isPopupOpen: summaryReducer.isPopupOpen
  };
};

const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    onSummaryPopupTriggerClick: () => dispatch(openSummaryModal()),
    onSummaryPopupClose: () => dispatch(closeSummaryModal())
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(SummaryComponent);
