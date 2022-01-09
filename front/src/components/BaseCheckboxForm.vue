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
      const model = [...this.model];

      if (check && !model.includes(id)) {
        model.push(id);
      } else {
        const index = model.indexOf(id);

        if (index < 0) {
          return;
        }

        model.splice(index, 1);
      }
      console.log(model);
      this.$emit("update", model);
    },
  },
};
</script>
