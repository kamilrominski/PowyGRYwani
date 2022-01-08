<template>
  <label class="form-control-label">{{ label }}</label>
  <select class="form-control form-control-alternative" v-model="localModel">
    <option v-for="option in options" :key="option.id">
      {{ option.name }}
    </option>
  </select>
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
      localModel: "",
    };
  },
  computed: {
    modelValue() {
      return this.options.find((o) => o.id === this.model)?.name;
    },
  },
  watch: {
    localModel(val) {
      if (val !== this.modelValue) {
        this.$emit(
          "update",
          this.options.find((o) => o.name === this.localModel)?.id
        );
      }
    },
    modelValue() {
      this.localModel = this.modelValue;
    },
  },
};
</script>
