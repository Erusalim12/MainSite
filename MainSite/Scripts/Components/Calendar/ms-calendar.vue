<template>
  <div class="card-panel">
    <div class="ms-calendar">
      <h6 style="text-align: center; color: #1e57a5">
        Основные мероприятия училища, предусмотренные планом-календарем на текущую неделю
      </h6>
      <div class="ms-calendar_carusel">
        <div class="ms-calendar_description">
          <template v-if="planCalendar && planCalendar.length">
            <div class="block_days">
              <div
                class="block_days-item"
                :class="{ active: selectedDay === index }"
                v-for="(item, index) in planCalendar"
                :key="`plan_${item.day}_${item.events.length}`"
                @click="onSelectDate(index)"
                v-html="infoDay(item)"
              ></div>
            </div>
            <ms-calendar-item
              :events="getEventsBySelectDay"
              :year="dateNow.getFullYear()"
              :month="dateNow.getMonth()"
            />
            <!--<input type="checkbox" class="read-more-checker" id="read-more-checker" />
            <div ref="limiter" class="limiter">
              <ms-calendar-item />
            </div>
            <label v-if="IsOverflowed" for="read-more-checker" class="read-more-button"></label>
            -->
          </template>
          <template v-else>
            <div class="text-center" style="color: #b12344">Мероприятий не запланировано</div>
          </template>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import { mapState, mapActions } from 'vuex';
  import msCalendarItem from './ms-calendar-item.vue';

  export default {
    name: 'ms-calendar',
    data() {
      return {
        selectedDay: -1,
      };
    },
    components: {
      msCalendarItem,
    },
    computed: {
      ...mapState('planCalendar', ['planCalendar']),
      getEventsBySelectDay() {
        if (this.selectedDay != -1) {
          return this.planCalendar[this.selectedDay].events;
        }

        return [];
      },
      dateNow() {
        return new Date();
      },
    },
    methods: {
      ...mapActions('planCalendar', ['GET_PLAN_CALENDAR']),
      onSelectDate(index) {
        this.selectedDay = index;
      },
      infoDay(obj) {
        const daysWeek = ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'];
        const dateConcreteDay = new Date(
          this.dateNow.getFullYear(),
          this.dateNow.getMonth(),
          obj.day,
        );

        const options = {
          day: 'numeric',
          month: 'numeric',
        };

        return `${dateConcreteDay.toLocaleDateString('ru', options)}, ${
          daysWeek[dateConcreteDay.getDay()]
        }`;
      },
    },
    async created() {
      if (this.planCalendar.length == 0) await this.GET_PLAN_CALENDAR();
      this.selectedDay = this.planCalendar.findIndex(
        (el) => Number(el.day) === this.dateNow.getDate(),
      );
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
