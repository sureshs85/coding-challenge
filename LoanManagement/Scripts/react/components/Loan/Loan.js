import React from 'react';
import "./Loan.css";
const loan = props =>
    <div className="wrapper">
        <div className="card">
            <div className="card-header">{props.id}. {props.name}</div>
            <div className="card-main">
                <span className="col1">Balance</span>
                <span className="col2">${props.balance}</span>
                <label className="col3 pure-material-checkbox">
                    <input type="checkbox" />
                    <span>Top Up</span>
                </label>
            </div>
            <div className="card-detail border-top">
                <span className="col1">Balance includes interest of</span>
                <span className="col2">${props.interest}</span>
            </div>
            <div className="card-detail">
                <span className="col1">Early repayment fee</span>
                <span className="col2">${props.repayment}</span>
            </div>
            <div className="card-detail">
                <span className="col1">Payout / Carryover amount</span>
                <span className="col2"><b>${props.payout}</b></span>
            </div>
        </div>
    </div>;
export default loan;