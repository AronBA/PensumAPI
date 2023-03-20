import json

with open("klassen.json", "r") as f:
    n = json.load(f)

insert = f"INSERT INTO tbl_Lektion VALUES "
count = 0
for klasse in n["data"]:
    for tag in n["data"][klasse]:
        for zeit in n["data"][klasse][tag]:
            count += 1
            if count > 990:
                count = 0
                insert = insert[:-1]
                insert += "\nINSERT INTO tbl_Lektion VALUES "
            arr = n["data"][klasse][tag][zeit]
            if len(arr) < 1:
                insert += f"('{klasse}','{tag}','{zeit}',NULL,NULL,NULL),"
                continue
            arr[0] = ''.join(arr[0].split())
            if len(arr) > 2:
                insert += f"('{klasse}','{tag}','{zeit}','{arr[0]}','{arr[1]}','{arr[2]}'),"
                continue
            insert += f"('{klasse}','{tag}','{zeit}','{arr[0]}',NULL,NULL),"

insert = insert[:-1]
print(insert)
