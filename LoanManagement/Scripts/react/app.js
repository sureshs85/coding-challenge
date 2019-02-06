import React from 'react';
import axios from 'axios';

class App extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            loans: []
        };
    }
    componentWillMount() {
        axios.get('http://localhost:55132/api/loan/getloans')
            .then(response => this.setState({ loans: response.data }));
    }
    render() {
        return (
            <div>
                {
                    this.state.loans.map((loan, index) => (
                        <div key={index}>
                            <span >{loan.LoanName}</span>
                            <br />
                        </div>
                    ))
                }
            </div>
        );
    }
}

export default App;
