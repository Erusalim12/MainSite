export default {
  CHANGE_STATE_ACTIVE(state, value = !state.isActive) {
    state.isActive = value;
  },
};
