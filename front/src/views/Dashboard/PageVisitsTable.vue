<template>
  <div class="card">
    <div class="card-header">
      <div class="row align-items-center">
        <div class="col">
          <h3 class="mb-0">Wynik wyszukiwania:</h3>
        </div>
      </div>
    </div>

    <div class="table-responsive">
      <base-table thead-classes="thead-light" :data="tableData">
        <template v-slot:columns>
          <th>Nazwa</th>
          <th>Typ</th>
        </template>

        <template v-slot:default="row">
          <th scope="row">
            <router-link
              :to="{
                name: getRouteType(row.item.type),
                params: { id: row.item.id },
              }"
            >
              {{ row.item.name }}
            </router-link>
          </th>
          <td>
            {{ transalteType(row.item.type) }}
          </td>
        </template>
      </base-table>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      tableData: [],
    };
  },
  methods: {
    getSearch() {
      this.axios.get(`/search/${this.$route.query.query}`).then((search) => {
        this.tableData = search.data;
      });
    },
    transalteType(type) {
      if (type === "studio") {
        return "Studio";
      } else if (type === "game") {
        return "Gra";
      } else {
        return "Seria";
      }
    },
    getRouteType(type) {
      if (type === "studio") {
        return "studio";
      } else if (type === "game") {
        return "game";
      } else {
        return "series";
      }
    },
  },

  watch: {
    "$route.query.query"() {
      this.getSearch();
    },
  },
  created() {
    this.getSearch();
  },
};
</script>
<style></style>
