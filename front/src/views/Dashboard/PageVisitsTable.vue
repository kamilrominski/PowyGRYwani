<template>
  <div class="card">
    <div class="card-header border-0">
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
          <th>Opis</th>
        </template>

        <template v-slot:default="row">
          <th scope="row">
            <router-link :to="{ name: 'gameEdit', params: { id: 'new' } }">
              {{ row.item.page }}
            </router-link>
          </th>
          <td>
            {{ row.item.visitors }}
          </td>
          <td style="overflow-y: auto">
            {{ row.item.unique }}
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
      tableData: [
        {
          page: "/argon/",
          visitors: "4,569",
          unique: " sd ",
          bounceRate: "46,53%",
          bounceRateDirection: "up",
        },
        {
          page: "/argon/index.html",
          visitors: "3,985",
          unique: "319",
          bounceRate: "46,53%",
          bounceRateDirection: "down",
        },
        {
          page: "/argon/charts.html",
          visitors: "3,513",
          unique: "294",
          bounceRate: "36,49%",
          bounceRateDirection: "down",
        },
        {
          page: "/argon/tables.html",
          visitors: "2,050",
          unique: "147",
          bounceRate: "50,87%",
          bounceRateDirection: "up",
        },
        {
          page: "/argon/profile.html",
          visitors: "1,795",
          unique: "190",
          bounceRate: "46,53%",
          bounceRateDirection: "down",
        },
      ],
    };
  },
};
</script>
<style></style>
