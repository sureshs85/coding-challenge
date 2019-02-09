const initialState = { loans: [] };
const reducer = (state = initialState, action) => {
    if (action.type === "LOANS") {
        return { loans: state.loans };
    }
    return state;
};
export default reducer;