import React from "react";
import { connect } from "react-redux";
import LoaderBar from "../../../controls/loader-bar/";

function Loader({ showLoader }) {
  return (
    <div className="loader-container">
      <LoaderBar show={showLoader}/>
      {showLoader && <div className="disabled-website"></div>}
    </div>
  );
}

const mapStateToProps = ({ loaderReducer }) => ({
  showLoader: loaderReducer.isFetching
});

export default connect(mapStateToProps)(Loader);
