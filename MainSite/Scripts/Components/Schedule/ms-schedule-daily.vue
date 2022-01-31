 <template>
  <div class="ms-schedule-daily col xl4 m6 s12">
    <div style="font-weight: bold">{{ currentDate }}</div>
    <div v-bind:class="{ active: dailyRasp.currentDay, card: true,daily:true }">
      <ul>
        <li v-for="(lesson, index) in ordered" :key="index">
          <div class="lesson-time center">{{ lesson.time }}</div>
          <div
            v-for="(para, index) in lesson.predmets"
            :key="index"
            class="card daily"
          >
            <div class="row ms-schedule-lesson">
              <div class="col s2">{{ para.groups.join(", ") }}</div>
              <div class="col s3">{{ para.predmetName }}</div>
              <div class="col s1">{{ para.theme }}/{{ para.lectionNum }}</div>
              <div class="col s1">{{ para.type }}</div>
              <div class="col s2">{{ para.educationRoom }}</div>
              <div class="col s3">{{ para.teacherFio }}</div>
            </div>
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

 <script>
import moment from "moment";
export default {
  name: "ms-schedule-daily",

  props: {
    dailyRasp: {
      type: Object,
      default() {
        return {};
      },
    },
  },
  methods: {},
  computed: {
    isVisible(lesson) {
      return lesson.length > 0;
    },
    ordered: function () {
      return this.dailyRasp.lessons.sort(function (a, b) {
        return a.lessonNumber > b.lessonNumber ? 1 : -1;
      });
    },

    currentDate: function () {
      //https://momentjs.com/  библиотека для работы с датами в JS
      return moment(this.dailyRasp.date).locale("ru").format("dddd, D MMMM");
    },
  },
};
</script>


<style>
.daily {
  display: flex;
  align-items: flex-start;
  justify-content: space-between;
  font-size: 14px;
  border-radius: 10px;
  color: rgb(0, 0, 0);
  border: 1px solid #aaa;
  padding-left: 4px;
  padding-right: 4px;
  transition: all 500ms;
  margin: auto;
}
.row{
  margin: 0;
}

.daily.active {
  color: rgb(13, 15, 145);
  border: 2px solid rgba(255, 1, 1, 0.897);
  padding-left: 4px;
  padding-right: 4px;
  font-weight: bold;
  background-color: #ffd;
}
.ms-schedule-lesson {
  text-align: center;
  vertical-align: middle;
}
</style>