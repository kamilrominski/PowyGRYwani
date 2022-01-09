<template>
  <label class="form-control-label">{{ label }}</label> <br />

  <base-checkbox
    v-for="option in options"
    :key="option.id"
    :checked="model && !!model.find((id) => id === option.id)"
    @input="handleInput($event, option.id)"
  >
    {{ option.name }}
  </base-checkbox>
</template>
<script>
export default {
  props: {
    model: Array,
    label: {
      type: [String],
    },
    options: Array,
  },
  methods: {
    handleInput(check, id) {
      const model = [...new Set([...this.model])];

      if (check) {
        model.push(id);
      } else {
        const index = model.indexOf(id);

        if (index < 0) {
          return;
        }

        model.splice(index, 1);
      }
      this.$emit("update", [...new Set(model)]);
    },
  },
};
</script>
