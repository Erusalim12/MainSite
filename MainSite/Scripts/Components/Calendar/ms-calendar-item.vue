<template>
  <div class="ms-calendar_item">
    <div v-if="!events.length" class="text-center" style="color: #b12344">
      Информация отсутствует
    </div>
    <div class="ms-calendar-description-event"
      v-for="event in getEventsOrderByTime()"
      :event="event"
      :key="event.id"
    >
    <div class="event-time">{{ event.time }}</div>
    <div class="event-name">{{ event.name }}</div>
    <div class="event-location">{{ event.location }}</div>
  </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'ms-calendar-item',
    props: {
      events: {
        type: Array,
        default: () => {
          return [];
        },
      },
    },
    methods: {
      getEventsOrderByTime() {
        return this.events
          .filter((el) => el.time)
          .sort(function (a, b) {
            let regExp = new RegExp(/\d{1,}.\d{1,}/g);
            let resA = a.time.match(regExp);
            let resB = b.time.match(regExp);
            let result = 0;

            if (resA != null && resB != null) {
              for (let i = 0; i < resA.length; i++) {
                if (result == 0 && typeof resB[i] != 'undefined') {
                  let timeFirstELement = Number(resA[i]);
                  let timeTwoElement = Number(resB[i]);

                  result = timeFirstELement - timeTwoElement;
                }
              }
              return result;
            } else if (resA == null) result = 100;
            else if (resB == null) result = -100;

            return result;
          });
      },
    },
  };
</script>

<style lang="scss">
  .ms-calendar_item {
    margin-top: 30px;

    .ms-calendar-description-event {
      color: black;
      display: flex;
      padding-bottom: 5px;
      line-height: 1.2;

      .event-time {
        padding-right: 5px;
        font-style: italic;
        font-weight: 300;
        flex-basis: 15%;
      }

      .event-name {
        padding-right: 5px;
        flex-basis: 65%;
        display: flex;
        align-self: center;
      }

      .event-location {
        flex-basis: 20%;
        font-style: italic;
        font-weight: 300;
        text-align: right;
      }
    }
  }
</style>
