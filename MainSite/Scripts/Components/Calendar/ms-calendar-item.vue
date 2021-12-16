<template>
  <div class="ms-calendar_item">
    <div v-if="!events.length" class="text-center" style="color: #b12344">
      Информация отсутствует
    </div>
    <transition-group name="list" tag="div">
      <div
        class="ms-calendar-description-event"
        v-for="event in getEventsOrderByTime()"
        :event="event"
        :key="event.id"
      >
        <div class="event-time">{{ event.time }}</div>
        <div class="event-name">{{ event.name }}</div>
        <div class="event-location">{{ event.location }}</div>
      </div>
    </transition-group>
  </div>
</template>

<script>
export default {
  name: "ms-calendar-item",
  props: {
    events: {
      type: Array,
      default: () => {
        return [];
      },
    },
  },
  data() {
    return {
      showEvents: true,
    };
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
              if (result == 0 && typeof resB[i] != "undefined") {
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
    beforeEnter(el) {
      el.style.opacity = 0;
      el.style.maxHeight = 0;
    },
    enter(el, done) {
      gsap.to(el, {
        opacity: 1,
        maxHeight: "1000px",
        delay: 0.15,
        onComplete: done,
      });
    },
    leave(el, done) {
      gsap.to(el, {
        opacity: 0,
        maxHeight: 0,
        delay: 0.15,
        onComplete: done,
      });
    },
  },
};
</script>

<style lang="scss">
.list-enter-active {
  transition: all 0.6s ease;
}
.list-enter,
.list-leave-to {
  transform: translateX(100%);
  opacity: 0;
}

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
