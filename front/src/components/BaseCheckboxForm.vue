<template>
  <label class="form-control-label">{{ label }}</label> <br />

  <base-checkbox
    v-for="option in options"
    :key="option.id"
    v-model="checkboxes[option.id]"
  >
    {{ option.name }}
  </base-checkbox>
</template>
<script>
export default {
  props: {
    model: [Number, String],
    label: {
      type: [String],
    },
    options: Array,
  },
  data() {
    return {
      checkboxes: {},
    };
  },

  watch: {
    checkboxes() {
      this.$emit("update", this.checkboxes);
    },
  },
};
</script>
