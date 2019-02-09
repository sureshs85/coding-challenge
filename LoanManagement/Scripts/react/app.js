import React from 'react';
import axios from 'axios';
import Loan from './components/Loan/Loan';
import { connect } from 'react-redux';

class App extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            loans: []
        };
    }
    componentWillMount() {
        axios.get('/api/loan/getloans')
            .then(response => this.setState({ loans: response.data }));
    }
    render() {
        return (
            <div>
                <p>
                    <h3>Personal Loan Topup or Apply</h3>
                </p>               
                <p className="border-top">
                   To apply for a TopUp of an existing loan amount, please select the loan below, make note of the Carry-over amount before proceeding
                </p>
                {
                    this.state.loans.map((loan, index) =>
                        <Loan
                            key={index}
                            id={index + 1}
                            name={loan.LoanName}
                            balance={loan.Balance}
                            interest={loan.Interest}
                            repayment={loan.RepaymentFee}
                            payout={loan.Payout}
                        />
                    )
                }
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        ctr: state.counter
    };
};
const mapDispatchToProps = dispatch => {
    return {
        onReceivedLoans: () => dispatch({ type: "LOANS" })
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(App);
