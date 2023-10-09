-- enums

create table role
(
    id   serial primary key,
    name varchar(150) unique not null
);

create table column_type
(
    id   serial primary key,
    name varchar(150) unique not null
);

create table card_type
(
    id   serial primary key,
    name varchar(150) unique not null
);

create table tag
(
    id   serial primary key,
    name varchar(150) unique not null
);

-- tables

create table users
(
    id        uuid primary key,
    full_name varchar(250)        not null,
    username  varchar(50)         not null unique,
    email     varchar(250)        not null unique,
    password  bytea               not null,
    letters   varchar(2)          not null,
    image_url text,
    role_id   int references role not null,
    deleted   bool                not null default false
);

create table workspace
(
    id                uuid primary key,
    name              varchar(150)          not null,
    created_timestamp timestamptz           not null default now(),
    created_user_id   uuid references users not null
);

create table workspace_table
(
    id                uuid primary key,
    name              varchar(150)              not null,
    created_timestamp timestamptz               not null default now(),
    created_user_id   uuid references users     not null,
    workspace_id      uuid references workspace not null
);

create table table_column
(
    id                 uuid primary key,
    name               varchar(150)                    not null,
    workspace_table_id uuid references workspace_table not null,
    type_id            int references column_type
);

create table card
(
    id                uuid primary key,
    header            varchar(300)                 not null,
    description       text,
    table_column_id   uuid references table_column not null,
    card_type_id      int references card_type     not null,
    created_user_id   uuid references users        not null,
    created_timestamp timestamptz                  not null default now(),
    deadline          timestamptz,
    deleted           bool                         not null default false
);

create table blocked_card
(
    id                    serial primary key,
    card_id               uuid references card  not null,
    comment               text,
    blocked_user_id       uuid references users not null,
    start_block_timestamp timestamptz           not null default now(),
    end_block_timestamp   timestamptz
);

create table card_tag
(
    id      serial primary key,
    card_id uuid references card not null,
    tag_id  int references tag   not null
);


create table card_users
(
    id      serial primary key,
    card_id uuid references card  not null,
    user_id uuid references users not null
);

create table card_comments
(
    id             serial primary key,
    card_id        uuid references card  not null,
    user_id        uuid references users not null,
    comment        text,
    attachment_url text,
    deleted        bool                  not null default false
);