import MsModal from "../ms-modal";

import axios from "axios";
import { mapState } from "vuex";

export default {
  name: "ms-feedback-question-modal",
  data() {
    return {
      model: {},
    };
  },
  computed: {
    ...mapState("user", ["currentUser"]),
  },
  methods: {
    close() {
      let modelResult = {
        customerId: this.currentUser.SystemName,
        answers: [{ message: this.$refs.answer.value }],
      };
      axios.post("/api/Question/addQuestion", modelResult).then((promise) => {
        this.$modals.close(promise.data);
      });
      ///this.$modals.close(modelResult)
    },
    cancel() {
      this.$modals.dismiss();
    },
  },
  render() {
    return (
      <MsModal>
        <div slot="body" class="s12 m12">
          <div class="bold">Задайте вопрос:</div>
          <textarea ref="answer" class="inputTextMainSite"></textarea>
        </div>
        <div slot="footer" style="display:flex;justify-content: space-between;">
          <button
            style="padding: 0px 30px;"
            class="btn btn-defaultMainSite"
            onClick:prevent={this.cancel}
          >
            отмена
          </button>
          <span
            style="padding: 0px 30px;"
            class="btn btn-defaultMainSite"
            onClick:prevent={this.close}
          >
            сохранить
          </span>
        </div>
      </MsModal>
    );
  },
};
