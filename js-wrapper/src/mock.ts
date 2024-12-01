import { DiscordSDK, DiscordSDKMock } from "@discord/embedded-app-sdk";
import { IDiscordSDK, SdkConfiguration } from "../node_modules/@discord/embedded-app-sdk/output/interface";
import { EventNames, EventPayloads, Mock } from "./types";
import { EventSchema } from "../node_modules/@discord/embedded-app-sdk/output/schema/events";
import {createSDKConfig, ready, getCommands , subscribeToEvent } from "./wrapper"
var guildID: string | null = null;
var channelID: string | null = null;

function setGuildID(id: string) {
    guildID = id;
}

function setChannelID(id: string) {
    channelID = id;
}
function instantiateSDK(clientID: string, config?: SdkConfiguration | undefined) {
    return new DiscordSDKMock(clientID, guildID, channelID);
}

function emitEvent<T extends EventNames>(sdk: DiscordSDKMock, eventName: T, eventData: string) {
    sdk.emitEvent(eventName, JSON.parse(eventData));
}

function emitReady(sdk: DiscordSDKMock) {
    sdk.emitReady();
}

window.DiscordWrapper = {
    setGuildID,
    setChannelID,
    emitEvent,
    emitReady,
    createSDKConfig,
    instantiateSDK,
    subscribeToEvent,
    ready,
    getCommands
} satisfies Mock;

export { setGuildID, setChannelID, createSDKConfig, instantiateSDK, ready, getCommands, emitEvent, emitReady };