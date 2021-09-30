import React from "react";
import { connect } from "react-redux";
import SummaryDetailsRow from './summaryDetailsRow';
import LoaderBar from "../../../controls/loader-bar";
import { fetchSummary } from "../actions";
import moneyPipe from "../../../pipes/moneyPipe";


class SummaryDetailsComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        this.props.onSummaryReload(
            this.props.itemTypeId,
            this.props.selectedExtras,
            this.props.from,
            this.props.to);
    }

    render() {
        if (!this.props.data || this.props.isFetching)
            return <LoaderBar show={this.props.isFetching} />
        else
            return (<div className='summary-groups'>
                <div className='item-card summary-group'>
                    <SummaryDetailsRow name='Vehicele' value={this.props.data.itemTypeName} />
                    <SummaryDetailsRow name='From' value={this.props.from.format("MM-DD-YYYY")} />
                    <SummaryDetailsRow name='To' value={this.props.to.format("MM-DD-YYYY")} />
                </div>
                {this.props.data.extras && this.props.data.extras.length > 0 && <div className='item-card summary-group'>
                    {this.props.data.extras && this.props.data.extras.map(x => <SummaryDetailsRow name={x.name} value={moneyPipe(x.price)} />)}
                </div>}
                <div className='item-card summary-group'>
                    <SummaryDetailsRow name='Total amount' value={moneyPipe(this.props.data.overallPrice)} />
                </div>

            </div>)

    }
}

const mapStateToProps = ({ dateStepReducer, itemStepReducer, extrasStepReducer, summaryReducer }) => {
    return {
        isFetching: summaryReducer.isFetching,
        from: dateStepReducer.dateFrom,
        to: dateStepReducer.dateTo,
        itemTypeId: itemStepReducer.selectedItemId,
        selectedExtras: extrasStepReducer.extras.filter(x => x.selected).map(x => x.id),
        data: summaryReducer.data
    };
};

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        onSummaryReload: (itemTypeId, extrasIds, from, to) => dispatch(fetchSummary(itemTypeId, extrasIds, from, to))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SummaryDetailsComponent);
