<template>
  <div class="card-panel">
    <div class="ms-calendar">
      <h6 style="text-align: center; color: #1e57a5">
        Основные мероприятия училища, предусмотренные планом-календарем
      </h6>
      <div class="ms-calendar_carusel">
        <div class="ms-calendar_description">
          <template v-if="planCalendar && Object.keys(planCalendar).length > 0">
            <div class="block_days">
              <div
                class="block_days-item"
                v-for="key in sortKeysCalendarByDate"
                :key="`plan_${key}}`"
                @click="onSelectDate(key)"
                :class="{ active: key == selectedDay }"
                v-html="infoDay(planCalendar[key].date)"
              ></div>
            </div>
            <ms-calendar-item :events="getEventsBySelectDay" />
          </template>
          <template v-else>
            <div class="text-center" style="color: #b12344">
              Мероприятий не запланировано
            </div>
          </template>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from "vuex";

import msCalendarItem from "./ms-calendar-item.vue";

export default {
  name: "ms-calendar",
  data() {
    return {
      selectedDay: -1,
    };
  },
  components: {
    msCalendarItem,
  },
  computed: {
    ...mapState("planCalendar", ["planCalendar"]),
    getEventsBySelectDay() {
      if (this.selectedDay != -1) {
        return this.planCalendar[this.selectedDay].events.filter(
          (el) => el.time
        );
      }

      return [];
    },
    dateNow() {
      return new Date();
    },
    sortKeysCalendarByDate() {
      return Object.keys(this.planCalendar).sort(
        (a, b) =>
          new Date(this.planCalendar[a].date).getTime() -
          new Date(this.planCalendar[b].date).getTime()
      );
    },
  },
  methods: {
    ...mapActions("planCalendar", ["GET_PLAN_CALENDAR"]),
    onSelectDate(index) {
      this.selectedDay = index;
    },
    infoDay(date) {
      const daysWeek = ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"];
      const dateConcreteDay = new Date(date);

      const options = {
        day: "numeric",
        month: "numeric",
      };

      return `${dateConcreteDay.toLocaleDateString("ru", options)}, ${
        daysWeek[dateConcreteDay.getDay()]
      }`;
    },
    sortedDate(a, b) {
      let dateA = new Date(a).getTime();
      let dateB = new Date(b).getTime();
      return dateA > dateB ? 1 : -1;
    },
  },
  created() {
    if (!this.planCalendar.length) this.GET_PLAN_CALENDAR();

    this.selectedDay = Number(this.dateNow.getDate());
  },
};
</script>

<style lang="scss">
.ms-calendar {
  font-size: 14px;
  position: relative;
  margin: 0 auto;

  &_back {
    position: absolute;
    z-index: 10;
    right: 0;
    top: 0;
  }

  &_description {
    .block_days {
      display: flex;
      flex-wrap: wrap;
      font-size: 16px;
      justify-content: flex-start;

      @media (max-width: 1210px) {
        font-size: 14px;
      }

      &-item {
        display: flex;
        cursor: pointer;
        align-items: center;
        padding: 10px 10px 10px 10px;

        &:hover,
        &.active {
          background: rgba(0, 0, 0, 0.02);
          border-bottom: 2px solid #64b5f6;
          padding-bottom: 8px;
        }

        &.active {
          background: rgba(0, 0, 0, 0);
        }
      }
    }
  }
  &_carusel {
    position: relative;
    overflow: hidden;
    flex-direction: row;
    margin-left: 15px;
    margin-right: 15px;
    left: 0px;
    transition-property: left;
    transition-duration: 0.3s;
    transition-timing-function: cubic-bezier(0, 0, 0.12, 0.89);
  }
}
</style>
